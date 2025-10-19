using BudgetApproved.Services;
using System;

var builder = WebApplication.CreateBuilder(args);


var budgetApiBaseUrl = builder.Configuration["BudgetApiSettings:BaseUrl"];

if (string.IsNullOrEmpty(budgetApiBaseUrl))
{
    throw new InvalidOperationException("Configurația 'BudgetApiSettings:BaseUrl' lipsește sau este goală în appsettings.json.");
}

builder.Services.AddHttpClient<IHttpClientService, HttpClientService>(client =>
{
    client.BaseAddress = new Uri(budgetApiBaseUrl);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});



builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
