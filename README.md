# MyPortfolioWebsite (Public Repo)

This is a public repository for **Rachael Miki Buxton's portfolio website** as of 2022/11/29.

## Infrastructure & Other Technologies Used
- Hosted on: Azure Web Apps
- Backend:
  - .NET MVC
  - PostgreSQL -- Using Cockroach DB (free tier 💰)
- Frontend:
  - Razor Pages
  - HTML
  - CSS (SASS)
  - JavaScript
- Other:
  - Icons: [FontAwesome]([https://](https://fontawesome.com/)) and [Devicon](https://devicon.dev/)
  - Title font: [Google Fonts](https://fonts.google.com/about)
  - Domain: [Google Domains](https://domains.google/)

## Disclaimer
This repo exists as a means of demonstration, and therefore:
- API keys / passwords are omitted from the code.
- Is not used for CI/CD.
- There exists a private repository in which all of the version management and CI/CD is done.

## Plausible Questions
1. Why are the API keys / passwords written directly in CockroachDB.cs instead of appsettings.json or some .env file?
   - At the time I was actively developing this website, as a noob, I was not aware of many general practices.
   - Planning to put API keys / passwords in appsettings.json for the next rendition of this website.
2. Why isn't Entity Framework Core (EF Core) used if it is a .NET web app connecting to a database?
   - As a noob, I did not have the slightest idea to use it🤦‍♀️
   - Will be using EF Core for the next rendition of my website.

Finally, please feel free to contact me if there are any questions or comments.
