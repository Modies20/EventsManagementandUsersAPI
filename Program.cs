using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventsEase.Data;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EventsEaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventsEaseContext") ?? throw new InvalidOperationException("Connection string 'EventsEaseContext' not found.")));

//Register the BlobStorageService
builder.Services.AddSingleton(new BlobServiceClient(builder.Configuration.GetConnectionString("BlobStorage") ?? throw new InvalidOperationException("Connection string 'BlobStorage' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["ConnectionStrings:BlobStorage:blobServiceUri"]!).WithName("ConnectionStrings:BlobStorage");
    clientBuilder.AddQueueServiceClient(builder.Configuration["ConnectionStrings:BlobStorage:queueServiceUri"]!).WithName("ConnectionStrings:BlobStorage");
    clientBuilder.AddTableServiceClient(builder.Configuration["ConnectionStrings:BlobStorage:tableServiceUri"]!).WithName("ConnectionStrings:BlobStorage");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
