# BookList
BookList is a simple ASP.NET Core application that allows users to manage a list of books. The application provides functionalities to add, view, edit, and delete books. It uses Entity Framework Core with an in-memory database for data storage.



HERE YOU HAVE INSTRUCTIONS TRANSLATED FROM POLISH

These instructions are designed to explain what the application does (point 1),
what is needed for it to run correctly (point 2),
and how to run it (point 3).






## 1. Introduction

This guide pertains to the "Book List" application, which showcases the author's capabilities and the technologies chosen to realize the project. This is a web application developed using ASP.NET Core, utilizing Entity Framework for database interactions. Since this is a demonstrative application, it does not have a physical database whose handling/migration could be an additional burden. Instead, it uses an "InMemory" database, which saves data in the device's memory for as long as the application is running. To facilitate testing, two entries are initially added to the list ("Pan Tadeusz" and "Blood of Elves, the Witcher book 1"). Additional technologies used include descriptive languages such as HTML markup and CSS stylesheets. JavaScript, jQuery, and AJAX are used to manipulate content on the client-side, with communication occurring via JSON format.

The application's functionalities include:
- Displaying the user's book collection as a list,
- Adding new literary items,
- Editing existing records,
- Removing unwanted items from the list.

## 2. Requirements

To ensure the application runs correctly, the appropriate environment setup is required. Before starting, ensure you have the following tools installed:
- .NET SDK (3.1 or newer [used .NET CORE 3.1 and compatible EF versions] 5.*) [Download here](https://dotnet.microsoft.com/download)
- Git [Download here](https://git-scm.com/downloads) (optional, for cloning the repository)

The application was tested on Windows.

## 3. Running the Application

The application can be run in several ways; here are the most popular methods. Use the one that best suits your preferences.

### 3.1 Copying the "Book List Publish" Directory

The application has been published in the "Book List Publish" directory. Download this directory to your computer, find and run the `BookList.exe` file. A terminal window should open, resembling the one shown in Figure 1, if everything goes well.

After running the application, click the link in the terminal while holding down the Ctrl key, or type `https://localhost:5001` in your browser. If successful, an image like the one in Figure 2 should appear.

Possible issues:
1. The terminal window may open and then close automatically. This could be caused by antivirus software. Remove the `BookList.exe` file from quarantine (I had this issue with Avast).
2. Lack of an SSL certificate; the browser may display a message about a potential threat from the application. Click "more information" (or similar) and then proceed to the page.

### 3.2 Running from the Repository with Manual Build

To clone the repository and run the application, follow these steps:

#### Step 1. Cloning the Repository

First, clone the repository from GitHub to your local computer:

```bash
git clone https://github.com/YourRepository/BookList.git
cd BookList
```

#### Step 2. Configuring the Application

You don't need to configure the database as the application uses an InMemory database. You can proceed directly to running the application.

Choose one of the following options depending on your operating system (Step 3.*):

#### Step 3.1. Running the Application on Windows

Open Command Prompt or PowerShell, navigate to the project directory, and run the following commands:

```powershell
cd path\to\BookList
dotnet restore
dotnet build
dotnet run
```

After running the application, open a web browser and go to `https://localhost:5001` or `http://localhost:5000` for HTTP.

#### Step 3.2. Running the Application on Linux

Open a terminal, navigate to the project directory, and run the following commands:

```bash
cd path/to/BookList
dotnet restore
dotnet build
dotnet run
```

After running the application, open a web browser and go to `https://localhost:5001` (or `http://localhost:5000` for HTTP).

#### Step 3.3. Sample Docker Configuration (Optional)

If you wish to run the application using Docker, prepare a `Dockerfile`:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["BookList/BookList.csproj", "BookList/"]
RUN dotnet restore "BookList/BookList.csproj"
COPY . .
WORKDIR "/src/BookList"
RUN dotnet build "BookList.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookList.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookList.dll"]
```

Then build and run the Docker container:

```bash
docker build -t booklist .
docker run -d -p 8080:80 --name booklist_app booklist
```

The application will be available at `http://localhost:8080`.

---

By following these instructions, you can easily set up and run the "Book List" application on both Windows and Linux environments. The provided scripts and Docker configuration streamline the process, making it more accessible for various users.
