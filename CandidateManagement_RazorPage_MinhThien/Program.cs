using Candidate_Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddSession(); 


builder.Services.AddScoped<IHRAccountService, HRAccountService>();
builder.Services.AddScoped<ICandidateProfileService, CandidateProfileService>();
builder.Services.AddScoped<IJobPostingService, JobPostingService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); 

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();


app.MapGet("/", context =>
{
    context.Response.Redirect("/LoginPages/Login");
    return Task.CompletedTask;
});

app.Run();