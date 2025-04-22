using Microsoft.EntityFrameworkCore;
using trackracer.Services;
using trackracer.DBContext;
using trackracer.Interfaces;
using trackracer.api.Interfaces;
using trackracer.api.Services;
using Microsoft.AspNetCore.SignalR;
using trackracer.RacerPages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Eddy connection string for the database
builder.Services.AddDbContext<DatabaseContext>
    (options =>
    options.UseSqlite("Data Source=C:\\Users\\lomn_\\Downloads\\TrackerDB\\MyTrackerDB.db"));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAccountsManager, AccountManager>();
builder.Services.AddScoped<ITrackingRequestStatusManager, TrackingRequestStatusManager>();
builder.Services.AddScoped<IChatManager, ChatManager>();

// Add SignalR service for real-time communication
builder.Services.AddSignalR();

// Add controllers and swagger for API documentation
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map SignalR Hub for real-time chat communication


app.MapHub<ChatSignalHub>("/chatsignalhub");


// Map API controllers
app.MapControllers();

app.Run();
