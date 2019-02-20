# **Cloud.Core.Testing**

<div id="description">

Testing utility package used by Cloud packages.  All reusable test helpers should live in this package to be reused through testing projects.

</div>

## Usage
### Trait builders
Contains a set of Is* trait attributes that aggregate specific trait categories, to facilitate control over build test filters:

- **IsUnit** - "Unit"
- **IsIntegration** - "Integration"
- **IsIntegrationReadOnly** - "Integration" + "ReadOnly"
- **IsPerformance** - "Performance"

This list can be added to when the build-release pipeline is defined.  Use in the Build/Test step with this command:

`dotnet test *ProjectName*.Test.csproj --filter "Category=Unit"`

### Lorem Ipsum helper
It could be useful during tests to generate a list of text used in test cases.  The Lorem Ipsum helper has been defined to do this.  Generate words, sentences and paragraphs as follows:

`
var loremWords = Cloud.Core.Testing.Lorem.Lorem.GetWords(10);
var loremSentences = Cloud.Core.Testing.Lorem.Lorem.GetSentences(2);
var loremParagraphs = Cloud.Core.Testing.Lorem.Lorem.GetParagraph(5);
`

## Test Coverage
A threshold will be added to this package to ensure the test coverage is above 80% for branches, functions and lines.  If it's not above the required threshold 
(threshold that will be implemented on ALL of the new core repositories going forward), then the build will fail.

## Compatibility
This package has has been written in .net Standard and can be therefore be referenced from a .net Core or .net Framework application. The advantage of utilising from a .net Core application, 
is that it can be deployed and run on a number of host operating systems, such as Windows, Linux or OSX.  Unlike referencing from the a .net Framework application, which can only run on 
Windows (or Linux using Mono).
 
## Setup
This package requires the .net Core 2.1 SDK, it can be downloaded here: 
https://www.microsoft.com/net/download/dotnet-core/2.1

IDE of Visual Studio or Visual Studio Code, can be downloaded here:
https://visualstudio.microsoft.com/downloads/

## How to access this package
All of the Cloud.Core.* packages are published to our internal NuGet feed.  To consume this on your local development machine, please add the following feed to your feed sources in Visual Studio:
TBC

For help setting up, follow this article: https://docs.microsoft.com/en-us/vsts/package/nuget/consume?view=vsts
