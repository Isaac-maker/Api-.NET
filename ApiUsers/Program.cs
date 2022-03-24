using ApiUsers.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( SwaggerGenOptions=>
{
    SwaggerGenOptions.SwaggerDoc("v1",new OpenApiInfo {Title ="Api ASP.Net React",Version="v1"});
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI( SwaggerUIOptionS =>
{
    SwaggerUIOptionS.DocumentTitle = "Api ASP.Net React";
    SwaggerUIOptionS.SwaggerEndpoint("/swagger/v1/swagger.json", "Api facilita");
    SwaggerUIOptionS.RoutePrefix = String.Empty;
});

app.UseHttpsRedirection();


app.MapGet("/get-all-posts", async () => await PostsRepository.GetPostsAsync()).WithTags("Posts Endpoints");




app.MapGet("/get-post-by-id/{id}", async (int id) =>
{
    Post postToReturn = await PostsRepository.GetPostByIdAsync(id);

    if(postToReturn != null)
    {
        return Results.Ok(postToReturn);
    }
    else
    { 
        return Results.BadRequest(); 
    }

}
).WithTags("Posts Endpoints");



app.MapPost("/create-post", async (Post postToCreate) =>
{
    bool createSucceful= await PostsRepository.CreatePostAsync(postToCreate);

    if (createSucceful)
    {
        return Results.Ok("Creado correctamente");
    }
    else
    {
        return Results.BadRequest();
    }

}
).WithTags("Posts Endpoints");


app.MapPut("/update-post", async (Post postToUpdate) =>
{
    bool updateSucceful = await PostsRepository.UpdatePostAsync(postToUpdate);

    if (updateSucceful)
    {
        return Results.Ok("Actualizado correctamente papillo");
    }
    else
    {
        return Results.BadRequest();
    }

}
).WithTags("Posts Endpoints");

app.MapDelete("/delete-by-id/{id}", async (int id) =>
{
    bool deleteSucceful = await PostsRepository.DeletePostAsync(id);

    if (deleteSucceful)
    {
        return Results.Ok("Eliminado correctamente carita fachera");
    }
    else
    {
        return Results.BadRequest();
    }

}
).WithTags("Posts Endpoints");



app.Run();
