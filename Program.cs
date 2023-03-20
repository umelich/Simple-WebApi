using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app. MapGet("/", () => "Hello World!");

//app.UseWelcomePage();

//app.Run(async (context) => await context.Response.WriteAsync("Hello"));

// app.Run(async (context) =>
// {
//     var response = context.Response;
//     response.ContentType = "text/html; charset=utf-8";
//     await response.WriteAsync("<h2>Hello</h2><h3>Welcome to ASP.NET Core</h3>");
// });

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");

//    foreach (var header in context.Request.Headers)
//    {
//        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

////app.Run(async (context) =>
////{
////    //context.Response.StatusCode = 404;

////    await context.Response.WriteAsync("<h2>Hello</h2><h3>Welcome to ASP.NET Core</h3>");
////});

//app.Run(async (context) =>
//{
//    var path = context.Request.Path;
//    var fullPath = $"html/{path}";
//    var response = context.Response;

//    response.ContentType = "text/html; charset=utf-8";
//    if (File.Exists(fullPath))
//    {
//        await response.SendFileAsync(fullPath);
//    }
//    else
//    {
//        response.StatusCode = 404;
//        await response.WriteAsync("<h2>Not Found</h2>");
//    }
//});

//app.Run(async (context) =>
//{
//    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
//    var fileinfo = fileProvider.GetFileInfo("forest.jpg");

//    context.Response.Headers.ContentDisposition = "attachment; filename=my_forest2.jpg";
//    await context.Response.SendFileAsync(fileinfo);
//});

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    // ���� ��������� ���� �� ������ "/postuser", �������� ������ �����
//    if (context.Request.Path == "/postuser")
//    {
//        var form = context.Request.Form;
//        string name = form["name"];
//        string age = form["age"];
//        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
//    }
//    else
//    {
//        await context.Response.SendFileAsync("html/index.html");
//    }
//});

//app.Run(async (context) =>
//{
//    Person tom = new("Tom", 22);
//    await context.Response.WriteAsJsonAsync(tom);
//});
//app.Run();

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;
//    if (request.Path == "/api/user")
//    {
//        var message = "������������ ������";   // ���������� ��������� �� ���������
//        try
//        {
//            // �������� �������� ������ json
//            var person = await request.ReadFromJsonAsync<Person>();
//            if (person != null) // ���� ������ ��������������� � Person
//                message = $"Name: {person.Name}  Age: {person.Age}";
//        }
//        catch { }
//        // ���������� ������������ ������
//        await response.WriteAsJsonAsync(new { text = message });
//    }
//    else
//    {
//        response.ContentType = "text/html; charset=utf-8";
//        await response.SendFileAsync("html/index.html");
//    }
//});

//app.Run();

//public record Person(string Name, int Age);

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;
//    if (request.Path == "/api/user")
//    {
//        var responseText = "������������ ������";   // ���������� ��������� �� ���������

//        if (request.HasJsonContentType())
//        {
//            // ���������� ��������� ������������/��������������
//            var jsonoptions = new JsonSerializerOptions();
//            // ��������� ��������� ���� json � ������ ���� Person
//            jsonoptions.Converters.Add(new PersonConverter());
//            // ������������� ������ � ������� ���������� PersonConverter
//            var person = await request.ReadFromJsonAsync<Person>(jsonoptions);
//            if (person != null)
//                responseText = $"Name: {person.Name}  Age: {person.Age}";
//        }
//        await response.WriteAsJsonAsync(new { text = responseText });
//    }
//    else
//    {
//        response.ContentType = "text/html; charset=utf-8";
//        await response.SendFileAsync("html/index.html");
//    }
//});

//app.Run();

//public record Person(string Name, int Age);
//public class PersonConverter : JsonConverter<Person>
//{
//    public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//    {
//        var personName = "Undefined";
//        var personAge = 0;
//        while (reader.Read())
//        {
//            if (reader.TokenType == JsonTokenType.PropertyName)
//            {
//                var propertyName = reader.GetString();
//                reader.Read();
//                switch (propertyName?.ToLower())
//                {
//                    // ���� �������� age � ��� �������� �����
//                    case "age" when reader.TokenType == JsonTokenType.Number:
//                        personAge = reader.GetInt32();  // ��������� ����� �� json
//                        break;
//                    // ���� �������� age � ��� �������� ������
//                    case "age" when reader.TokenType == JsonTokenType.String:
//                        string? stringValue = reader.GetString();
//                        // �������� �������������� ������ � �����
//                        if (int.TryParse(stringValue, out int value))
//                        {
//                            personAge = value;
//                        }
//                        break;
//                    case "name":    // ���� �������� Name/name
//                        string? name = reader.GetString();
//                        if (name != null)
//                            personName = name;
//                        break;
//                }
//            }
//        }
//        return new Person(personName, personAge);
//    }
//    // ����������� ������ Person � json
//    public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
//    {
//        writer.WriteStartObject();
//        writer.WriteString("name", person.Name);
//        writer.WriteNumber("age", person.Age);

//        writer.WriteEndObject();
//    }
//}



//using System.Text.RegularExpressions;

//// ��������� ������
//List<Person> users = new List<Person>
//{
//    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
//    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
//    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 }
//};

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;
//    var path = request.Path;
//    //string expressionForNumber = "^/api/users/([0-9]+)$";   // ���� id ������������ �����

//    // 2e752824-1657-4c7f-844b-6ec2e168e99c
//    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
//    if (path == "/api/users" && request.Method == "GET")
//    {
//        await GetAllPeople(response);
//    }
//    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
//    {
//        // �������� id �� ������ url
//        string? id = path.Value?.Split("/")[3];
//        await GetPerson(id, response);
//    }
//    else if (path == "/api/users" && request.Method == "POST")
//    {
//        await CreatePerson(response, request);
//    }
//    else if (path == "/api/users" && request.Method == "PUT")
//    {
//        await UpdatePerson(response, request);
//    }
//    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
//    {
//        string? id = path.Value?.Split("/")[3];
//        await DeletePerson(id, response);
//    }
//    else
//    {
//        response.ContentType = "text/html; charset=utf-8";
//        await response.SendFileAsync("html/index.html");
//    }
//});

//app.Run();

//// ��������� ���� �������������
//async Task GetAllPeople(HttpResponse response)
//{
//    await response.WriteAsJsonAsync(users);
//}
//// ��������� ������ ������������ �� id
//async Task GetPerson(string? id, HttpResponse response)
//{
//    // �������� ������������ �� id
//    Person? user = users.FirstOrDefault((u) => u.Id == id);
//    // ���� ������������ ������, ���������� ���
//    if (user != null)
//        await response.WriteAsJsonAsync(user);
//    // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
//    else
//    {
//        response.StatusCode = 404;
//        await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
//    }
//}

//async Task DeletePerson(string? id, HttpResponse response)
//{
//    // �������� ������������ �� id
//    Person? user = users.FirstOrDefault((u) => u.Id == id);
//    // ���� ������������ ������, ������� ���
//    if (user != null)
//    {
//        users.Remove(user);
//        await response.WriteAsJsonAsync(user);
//    }
//    // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
//    else
//    {
//        response.StatusCode = 404;
//        await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
//    }
//}

//async Task CreatePerson(HttpResponse response, HttpRequest request)
//{
//    try
//    {
//        // �������� ������ ������������
//        var user = await request.ReadFromJsonAsync<Person>();
//        if (user != null)
//        {
//            // ������������� id ��� ������ ������������
//            user.Id = Guid.NewGuid().ToString();
//            // ��������� ������������ � ������
//            users.Add(user);
//            await response.WriteAsJsonAsync(user);
//        }
//        else
//        {
//            throw new Exception("������������ ������");
//        }
//    }
//    catch (Exception)
//    {
//        response.StatusCode = 400;
//        await response.WriteAsJsonAsync(new { message = "������������ ������" });
//    }
//}

//async Task UpdatePerson(HttpResponse response, HttpRequest request)
//{
//    try
//    {
//        // �������� ������ ������������
//        Person? userData = await request.ReadFromJsonAsync<Person>();
//        if (userData != null)
//        {
//            // �������� ������������ �� id
//            var user = users.FirstOrDefault(u => u.Id == userData.Id);
//            // ���� ������������ ������, �������� ��� ������ � ���������� ������� �������
//            if (user != null)
//            {
//                user.Age = userData.Age;
//                user.Name = userData.Name;
//                await response.WriteAsJsonAsync(user);
//            }
//            else
//            {
//                response.StatusCode = 404;
//                await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
//            }
//        }
//        else
//        {
//            throw new Exception("������������ ������");
//        }
//    }
//    catch (Exception)
//    {
//        response.StatusCode = 400;
//        await response.WriteAsJsonAsync(new { message = "������������ ������" });
//    }
//}
//public class Person
//{
//    public string Id { get; set; } = "";
//    public string Name { get; set; } = "";
//    public int Age { get; set; }
//}
//-------------------------------------------------------------------------------
//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;

//    response.ContentType = "text/html; charset=utf-8";

//    if (request.Path == "/upload" && request.Method == "POST")
//    {
//        IFormFileCollection files = request.Form.Files;
//        // ���� � �����, ��� ����� ��������� �����
//        var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
//        // ������� ����� ��� �������� ������
//        Directory.CreateDirectory(uploadPath);

//        foreach (var file in files)
//        {
//            // ���� � ����� uploads
//            string fullPath = $"{uploadPath}/{file.FileName}";

//            // ��������� ���� � ����� uploads
//            using (var fileStream = new FileStream(fullPath, FileMode.Create))
//            {
//                await file.CopyToAsync(fileStream);
//            }
//        }
//        await response.WriteAsync("����� ������� ���������");
//    }
//    else
//    {
//        await response.SendFileAsync("html/index.html");
//    }
//});

//app.Run();
//------------------------------------------------------------------------------
//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//string date = "";

//app.Use(async (context, next) =>
//{
//    date = DateTime.Now.ToShortDateString();
//    await next.Invoke();                 // �������� middleware �� app.Run
//    Console.WriteLine($"Current date: {date}");  // Current date: 08.12.2021
//});

//app.Run(async (context) => await context.Response.WriteAsync($"Date: {date}"));

//app.Run();

//--------------------------------------------------------------------------------
//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.UseWhen(
//    context => context.Request.Path == "/time", // ���� ���� ������� "/time"
//    appBuilder =>
//    {
//        // ��������� ������ - ������� �� ������� ����������
//        appBuilder.Use(async (context, next) =>
//        {
//            var time = DateTime.Now.ToShortTimeString();
//            Console.WriteLine($"Time: {time}");
//            await next();   // �������� ��������� middleware
//        });

//        // ���������� �����
//        appBuilder.Run(async context =>
//        {
//            var time = DateTime.Now.ToShortTimeString();
//            await context.Response.WriteAsync($"Time: {time}");
//        });
//    });

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("ASP.NET CORE");
//});

//app.Run();
//-----------------------------------------------------------------------
//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.MapWhen(
//    context => context.Request.Path == "/time", // �������: ���� ���� ������� "/time"
//    appBuilder => appBuilder.Run(async context =>
//    {
//        var time = DateTime.Now.ToShortTimeString();
//        await context.Response.WriteAsync($"current time: {time}");
//    })
//);

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("ASP.NET CORE");
//});

//app.Run();
//-------------------------------------------------------------------------
//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map("/time", appBuilder =>
//{
//    var time = DateTime.Now.ToShortTimeString();

//    // ��������� ������ - ������� �� ������� ����������
//    appBuilder.Use(async (context, next) =>
//    {
//        Console.WriteLine($"Time: {time}");
//        await next();   // �������� ��������� middleware
//    });

//    appBuilder.Run(async context => await context.Response.WriteAsync($"Time: {time}"));
//});

//app.Run(async (context) => await context.Response.WriteAsync("ASP.NET CORE"));

//app.Run();
//-------------------------------------------------------------------------
//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.UseMiddleware<TokenMiddleware>();

//app.Run(async (context) => await context.Response.WriteAsync("ASP.NET CORE"));

//app.Run();
//-------------------------------------------------------------------------
//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.UseToken();

//app.Run(async (context) => await context.Response.WriteAsync("ASP.NET CORE"));

//app.Run();
//-------------------------------------------------------------------------
//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.UseToken("555555");

//app.Run(async (context) => await context.Response.WriteAsync("ASP.NET CORE"));

//app.Run();
//-------------------------------------------------------------------------
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<RoutingMiddleware>();

app.Run();