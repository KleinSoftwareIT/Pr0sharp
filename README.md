# pr0sharp - C# pr0gramm.com API library
pr0sharp (alternative title pr0#) is an implementation of the API provided by the german imageboard [pr0gramm.com](https://pr0gramm.com) written purely in C#.
The library was born due to being necessary for the still ongoing project keyb0x.pro to handle auth and other functionality.

Licensed under MIT, the librarys goal is to allow quick and comfortable access to all API endpoints.

**NOTICE:** The library is still under construction, there are many things that aren't implemented yet while the current implementation might not be ideal or even work straight from the start.

# Design principles

Main design goal of the library is to be intuitive to use. Things like timestamps etc. should be ready to use (thorugh the use of converters), properties of the response objects should be named correctly.

At it's core the library uses a request-response pattern. Methods expecting input require a `..Request` object providing them with all data necessary instead of passing all required data directly as parameters. Returned data from the API endpoints will be similarly returned to the caller through a `..Response` which holds the requested information for further processing. Refer to the already existing code for further information on how to handle communication to and from the library.

# How to use

For the time being, to use the library you either need to compile it from source and grab the dll file or reference the csproj directly in your project.
It is planned to provide easier access to the library via Github releases and/or Nuget in the future

After somehow getting the library referenced in your project, these are the next steps:

1. Get yourself some API credentials to use. For more information on how to do that, see the official documentation located [here](https://github.com/pr0gramm-com/api-docs/blob/master/OAuth.md)
2. Create the url to start the OAuth flow, then follow through the authentication process. There are other libraries like `Duende.IdentityModel` which can help with this step. Make sure to set the scope(s) according to which data you want to retrieve from the API. At the end of the authentication flow you will obtain an access token. This will be the key for using the API, so store it securely.
3. Create a new instance of `pr0sharp.Pr0grammApiClient` and pass the obtained `AccessToken` as part of the constructor. The client will now configure everything necessary to successfully call any API endpoint (in accordance with the requested scopes, which will not be checked by the client)
4. Call any provided method, passing required arguments. If everything is done correctly, the respective response object will hold the requested data for further processing

# How to use the samples

1. Clone the repository
1. Get client credentials to use for the API. Refer to the above section on how to get those
1. Add the ClientID and the ClientSecret to `appsettings.development.json` (you need to create that file manually as it is ignored from git by default. Create an empty JSON file with that name, then only copy those keys you want to alter from the main file) Alternatively, you can add them to `appsettings.json` but take care to not commit the file with credentials in place, they have to remain secret
1. Run the Sample project, either via your IDE or on the command line via `dotnet run` while being in the `pr0sharp.Samples` directory. If you added/modified the `appsettings.development.json` mentioned above, then remember to run the samples in Debug configuration or else the values won't get picked up.
1. Your browser should now open where you can login with pr0gramm using your account. **Notice that every action you take on the samples can potentially affect the pr0gramm.com account you used to login to the samples**

# How to build

Building the library is super simple. All you need is `Visual Studio 2022` or any other C#-capable IDE like `JetBrains Rider`.
Simply open the solution file and hit `Build Project`.
Alternatively you can build the library on the command line via `dotnet build`.
In both cases the resulting binary will be placed in the respective subfolder of `/bin`

# How to contribute

Contributing to this project is super simple. Fork the project, add and commit your contributions and create a pull request. If everything looks fine, it will be merged and officially part of the library.
That's really all it takes. No CLA shenanigans or other things required.

# Credits
This repo contains references to third party software consumed by the library. For attribution and licenses, see [3rdPartyNotices.md](/3rdPartyNotices.md)
