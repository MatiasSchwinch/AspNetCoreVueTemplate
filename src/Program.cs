var builder = WebApplication.CreateBuilder(args);

// Añadido del appsettings correspondiente al entorno de ejecución.
builder.Configuration
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}", reloadOnChange: true, optional: true);

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    //! Solo se utiliza swagger si el entorno es desarrollo.
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "docs/swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/docs/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "docs";
    });
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
