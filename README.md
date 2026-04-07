Title: TheLunarGallop

Intended Purpose

TheLunarGallop is a full-stack web application designed to help users explore the rich traditions of the Chinese Zodiac. The app allows users to "Meet the Signs," learn about "Auspicious Flora" (lucky flowers), and use an interactive "Your Journey" tool. By entering their name and birth year, the app communicates with a C# Web API to calculate their specific zodiac sign and store their profile in an in-memory database.

How to Build and Run the Application:

Prerequisites:

    .NET 10.0 SDK

    Visual Studio Code

    C# Dev Kit Extension for VS Code

Steps to Run:

    Clone the Repository: Download or clone this folder to your local machine.

    Open in VS Code: Open the root folder (TheLunarGallop) in Visual Studio Code.

    Restore Dependencies: Open the terminal in VS Code and run:
    Bash

    dotnet restore

    Run the API: In the terminal, navigate to the API project and start the server:
    Bash

    dotnet run --project ZodiacAPI

    View the App: Look at the terminal output for the localhost URL (usually http://localhost:5000 or https://localhost:7001). Copy and paste that address into your web browser.

    Run Tests: To verify the backend logic, run:
    Bash

    dotnet test

Project Reflections:

What did you learn from this project?

Through this project, I learned how to bridge the gap between a static frontend and a dynamic backend. I gained hands-on experience setting up an ASP.NET Core Web API, creating Controllers to handle CRUD operations, and using the JavaScript Fetch API to send and receive JSON data. I also learned the importance of Automated Testing using xUnit to ensure that my zodiac calculation logic was accurate before deploying the UI.

What did you learn from this course?

This course taught me the full lifecycle of software development. I moved from basic HTML/CSS layouts to understanding how data is structured in C# and how to manage a project using a Solution (.sln) file in a professional environment. Most importantly, I learned how to troubleshoot complex errors between the client and the server.

If you had more time, what would you have done differently?

If I had more time, I would have implemented the following:

    Zodiac Compatibility: An additional feature to check compatibility and incompatibility between different signs.

    Parallax Web Structure: A more immersive, multi-layered visual experience on the frontend using parallax scrolling.

    Backend Refinement: I would have spent more time cleaning and optimizing the backend code, perhaps moving the in-memory data to a persistent SQL database.

Personal Growth

This project has been a major "aha!" moment for me. I’ve realized that I am definitely more proficient in frontend development; I enjoy the visual and interactive aspects of building a site. My biggest weakness is currently the backend, and I recognize that I need to improve my skills in that area.

Even after the capstone interview is over, I plan to continue improving this website until I am fully satisfied with the results.
