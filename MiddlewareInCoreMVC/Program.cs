using MiddlewareInCoreMVC.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Before Calling 1st app.Use()\n");
//    await next();
//    await context.Response.WriteAsync("After Calling from 1st app.Use()\n");
//});

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Before Calling 2nd app.Use()\n");
//    await next();
//    await context.Response.WriteAsync("After Calling 2nd app.Use()\n");
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
//});

////app.Use(async (context, next) =>
////{
////    await context.Response.WriteAsync("Before Calling 3rd app.Use()\n");
////    await next();
////    await context.Response.WriteAsync("After Calling 3rd app.Use()\n");
////});
// the following will never be executed    
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello from 2nd app.Run()\n");
//});

//app.Map("/m1", HandleMapOne);
//app.Map("/m2", appMap =>
//{
//    appMap.Run(async context =>
//    {
//        await context.Response.WriteAsync("Hello from 2nd app.Map()");
//    });
//});
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello from app.Run()");
//});
//static void HandleMapOne(IApplicationBuilder app)
//{
//    app.Run(async context =>
//    {
//        await context.Response.WriteAsync("Hello from 1st app.Map()");
//    });
//}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
//app.UseMiddleware<LoggingMiddleware>();
app.UseLogUrl();
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
