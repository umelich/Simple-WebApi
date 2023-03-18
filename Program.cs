//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.FileProviders;
//using System;
//using System.Text.Json.Serialization;
//using System.Text.Json;

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

////app. MapGet("/", () => "Hello World!");

////app.UseWelcomePage();

////app.Run(async (context) => await context.Response.WriteAsync("Hello"));

//// app.Run(async (context) =>
//// {
////     var response = context.Response;
////     response.ContentType = "text/html; charset=utf-8";
////     await response.WriteAsync("<h2>Hello</h2><h3>Welcome to ASP.NET Core</h3>");
//// });

////app.Run(async (context) =>
////{
////    context.Response.ContentType = "text/html; charset=utf-8";
////    var stringBuilder = new System.Text.StringBuilder("<table>");

////    foreach (var header in context.Request.Headers)
////    {
////        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
////    }
////    stringBuilder.Append("</table>");
////    await context.Response.WriteAsync(stringBuilder.ToString());
////});

//////app.Run(async (context) =>
//////{
//////    //context.Response.StatusCode = 404;

//////    await context.Response.WriteAsync("<h2>Hello</h2><h3>Welcome to ASP.NET Core</h3>");
//////});

////app.Run(async (context) =>
////{
////    var path = context.Request.Path;
////    var fullPath = $"html/{path}";
////    var response = context.Response;

////    response.ContentType = "text/html; charset=utf-8";
////    if (File.Exists(fullPath))
////    {
////        await response.SendFileAsync(fullPath);
////    }
////    else
////    {
////        response.StatusCode = 404;
////        await response.WriteAsync("<h2>Not Found</h2>");
////    }
////});

////app.Run(async (context) =>
////{
////    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
////    var fileinfo = fileProvider.GetFileInfo("forest.jpg");

////    context.Response.Headers.ContentDisposition = "attachment; filename=my_forest2.jpg";
////    await context.Response.SendFileAsync(fileinfo);
////});

////app.Run(async (context) =>
////{
////    context.Response.ContentType = "text/html; charset=utf-8";

////    // если обращение идет по адресу "/postuser", получаем данные формы
////    if (context.Request.Path == "/postuser")
////    {
////        var form = context.Request.Form;
////        string name = form["name"];
////        string age = form["age"];
////        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
////    }
////    else
////    {
////        await context.Response.SendFileAsync("html/index.html");
////    }
////});

////app.Run(async (context) =>
////{
////    Person tom = new("Tom", 22);
////    await context.Response.WriteAsJsonAsync(tom);
////});
////app.Run();

////app.Run(async (context) =>
////{
////    var response = context.Response;
////    var request = context.Request;
////    if (request.Path == "/api/user")
////    {
////        var message = "Ќекорректные данные";   // содержание сообщени€ по умолчанию
////        try
////        {
////            // пытаемс€ получить данные json
////            var person = await request.ReadFromJsonAsync<Person>();
////            if (person != null) // если данные сконвертированы в Person
////                message = $"Name: {person.Name}  Age: {person.Age}";
////        }
////        catch { }
////        // отправл€ем пользователю данные
////        await response.WriteAsJsonAsync(new { text = message });
////    }
////    else
////    {
////        response.ContentType = "text/html; charset=utf-8";
////        await response.SendFileAsync("html/index.html");
////    }
////});

////app.Run();

////public record Person(string Name, int Age);

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;
//    if (request.Path == "/api/user")
//    {
//        var responseText = "Ќекорректные данные";   // содержание сообщени€ по умолчанию

//        if (request.HasJsonContentType())
//        {
//            // определ€ем параметры сериализации/десериализации
//            var jsonoptions = new JsonSerializerOptions();
//            // добавл€ем конвертер кода json в объект типа Person
//            jsonoptions.Converters.Add(new PersonConverter());
//            // десериализуем данные с помощью конвертера PersonConverter
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
//                    // если свойство age и оно содержит число
//                    case "age" when reader.TokenType == JsonTokenType.Number:
//                        personAge = reader.GetInt32();  // считываем число из json
//                        break;
//                    // если свойство age и оно содержит строку
//                    case "age" when reader.TokenType == JsonTokenType.String:
//                        string? stringValue = reader.GetString();
//                        // пытаемс€ конвертировать строку в число
//                        if (int.TryParse(stringValue, out int value))
//                        {
//                            personAge = value;
//                        }
//                        break;
//                    case "name":    // если свойство Name/name
//                        string? name = reader.GetString();
//                        if (name != null)
//                            personName = name;
//                        break;
//                }
//            }
//        }
//        return new Person(personName, personAge);
//    }
//    // сериализуем объект Person в json
//    public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
//    {
//        writer.WriteStartObject();
//        writer.WriteString("name", person.Name);
//        writer.WriteNumber("age", person.Age);

//        writer.WriteEndObject();
//    }
//}



using System.Text.RegularExpressions;

// начальные данные
List<Person> users = new List<Person>
{
    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 }
};

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;
    //string expressionForNumber = "^/api/users/([0-9]+)$";   // если id представл€ет число

    // 2e752824-1657-4c7f-844b-6ec2e168e99c
    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
    if (path == "/api/users" && request.Method == "GET")
    {
        await GetAllPeople(response);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        // получаем id из адреса url
        string? id = path.Value?.Split("/")[3];
        await GetPerson(id, response);
    }
    else if (path == "/api/users" && request.Method == "POST")
    {
        await CreatePerson(response, request);
    }
    else if (path == "/api/users" && request.Method == "PUT")
    {
        await UpdatePerson(response, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await DeletePerson(id, response);
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

// получение всех пользователей
async Task GetAllPeople(HttpResponse response)
{
    await response.WriteAsJsonAsync(users);
}
// получение одного пользовател€ по id
async Task GetPerson(string? id, HttpResponse response)
{
    // получаем пользовател€ по id
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    // если пользователь найден, отправл€ем его
    if (user != null)
        await response.WriteAsJsonAsync(user);
    // если не найден, отправл€ем статусный код и сообщение об ошибке
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "ѕользователь не найден" });
    }
}

async Task DeletePerson(string? id, HttpResponse response)
{
    // получаем пользовател€ по id
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    // если пользователь найден, удал€ем его
    if (user != null)
    {
        users.Remove(user);
        await response.WriteAsJsonAsync(user);
    }
    // если не найден, отправл€ем статусный код и сообщение об ошибке
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "ѕользователь не найден" });
    }
}

async Task CreatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        // получаем данные пользовател€
        var user = await request.ReadFromJsonAsync<Person>();
        if (user != null)
        {
            // устанавливаем id дл€ нового пользовател€
            user.Id = Guid.NewGuid().ToString();
            // добавл€ем пользовател€ в список
            users.Add(user);
            await response.WriteAsJsonAsync(user);
        }
        else
        {
            throw new Exception("Ќекорректные данные");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Ќекорректные данные" });
    }
}

async Task UpdatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        // получаем данные пользовател€
        Person? userData = await request.ReadFromJsonAsync<Person>();
        if (userData != null)
        {
            // получаем пользовател€ по id
            var user = users.FirstOrDefault(u => u.Id == userData.Id);
            // если пользователь найден, измен€ем его данные и отправл€ем обратно клиенту
            if (user != null)
            {
                user.Age = userData.Age;
                user.Name = userData.Name;
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "ѕользователь не найден" });
            }
        }
        else
        {
            throw new Exception("Ќекорректные данные");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Ќекорректные данные" });
    }
}
public class Person
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int Age { get; set; }
}