# HomeHero

Windows desktop app (C# / .NET 8 / Windows Forms) that connects customers with home-service providers.
Three roles: **Customer**, **Service Provider** and **Administrator**.

## Run it from source (Visual Studio)
1. Install **Visual Studio 2022 (17.8+) or 2026** with the **".NET desktop development"** workload (includes the .NET 8 SDK).
2. Clone the repo, open `Home Hero.slnx` (or `Home Hero.csproj`).
3. Press **F5**.

Command line instead: `dotnet run --project "Home Hero.csproj"`

## Run it without installing anything (for group members)
On the machine that has the SDK, double-click **`publish.bat`**. It creates `publish\HomeHero.exe`
(self-contained, single file). Copy that one `.exe` to any 64-bit Windows 10/11 laptop and double-click it.

## Screen size
Designed for **1920 x 1080**. On smaller screens or with Windows scaling at 125% / 150% the windows
fit to the screen and show scroll bars instead of cutting content off.
Text stays sharp at any Windows scaling.

## Signing up and logging in
There is no "Login as" box. People choose their role **when they create an account** (Customer or Service
Provider sign-up, both reachable from the login screen). At login the app works out the account type from the
e-mail and password and opens the right dashboard (Administrator, Service Provider or Customer).
- While typing an e-mail, a small hint shows what was found ("Customer account found", "Service Provider account found",
  or "No account for this email yet").
- One e-mail = one identity: sign-up refuses an e-mail that is already used by any account type and offers to log in instead.
- After sign-up, choosing "log in now" opens the login screen with the e-mail already filled in.
- If an old data set has the same e-mail and password as both a customer and a provider, the app asks once which dashboard to open.
- Account lookup lives in `AccountDirectory.cs`.

## Where is the data stored?
In each user's own folder: `%LocalAppData%\HomeHero` (customers, providers, requests, `error.log`).
Every laptop therefore starts with its own empty data set. To reset the app, delete that folder.

## Known limitations
- Passwords and the "remember me" login are stored as plain text (student project - not for real use).
- Administrator accounts are hard-coded in `AccountDirectory.cs`.
