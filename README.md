# **Cloud.Core.Testing** [![Build status](https://dev.azure.com/cloudcoreproject/CloudCore/_apis/build/status/Cloud.Core/Cloud.Core.Testing_Package)](https://dev.azure.com/cloudcoreproject/CloudCore/_build/latest?definitionId=2) ![Code Coverage](https://cloud1core.blob.core.windows.net/codecoveragebadges/Cloud.Core.Testing-LineCoverage.png) [![Cloud.Core.Testing package in Cloud.Core feed in Azure Artifacts](https://feeds.dev.azure.com/cloudcoreproject/dfc5e3d0-a562-46fe-8070-7901ac8e64a0/_apis/public/Packaging/Feeds/8949198b-5c74-42af-9d30-e8c462acada6/Packages/4a4d803b-f864-4da1-8060-6af8efb0e3e6/Badge)](https://dev.azure.com/cloudcoreproject/CloudCore/_packaging?_a=package&feed=8949198b-5c74-42af-9d30-e8c462acada6&package=4a4d803b-f864-4da1-8060-6af8efb0e3e6&preferRelease=true) 

<img src="https://cloud1core.blob.core.windows.net/icons/cloud_core_small.png" />

<div id="description">
Testing utility package used in all Cloud.Core projects.  All reusable test helpers should live in this package to be reused through testing projects.
</div>

## Usage
### Trait builders
Contains a set of Is* trait attributes that aggregate specific trait categories, to facilitate control over build test filters:

- **IsDev** - "Dev"
- **IsUnit** - "Unit"
- **IsIntegration** - "Integration"
- **IsIntegrationReadOnly** - "Integration" + "ReadOnly"
- **IsSmoke** - "Smoke"
- **IsPerformance** - "Performance"

This list can be added to when the build-release pipeline is defined.

### Lorem Ipsum helper
It could be useful during tests to generate a list of text used in test cases.  The Lorem Ipsum helper has been defined to do this.  Generate words, sentences and paragraphs as follows:

```csharp
var loremWords = Cloud.Core.Testing.Lorem.Lorem.GetWords(10);
var loremSentences = Cloud.Core.Testing.Lorem.Lorem.GetSentences(2);
var loremParagraphs = Cloud.Core.Testing.Lorem.Lorem.GetParagraph(5);
```

### LogExecutionTime Attribute
The LogExecutionTime attribute can be used to output the time it takes a test to run to completion.

```csharp
[Fact]
[LogExecutionTime]
public void Test_Lorem_GetSingleParagraph()
{
	var paragraph = Lorem.Lorem.GetParagraph(3);

	var split = paragraph.Split('.').ToList();
	split.RemoveAll(string.IsNullOrEmpty);

	Assert.Equal(3, split.Count);
}
```

## Test Coverage
A threshold will be added to this package to ensure the test coverage is above 80% for branches, functions and lines.  If it's not above the required threshold 
(threshold that will be implemented on ALL of the core repositories to gurantee a satisfactory level of testing), then the build will fail.

## Compatibility
This package has has been written in .net Standard and can be therefore be referenced from a .net Core or .net Framework application. The advantage of utilising from a .net Core application, 
is that it can be deployed and run on a number of host operating systems, such as Windows, Linux or OSX.  Unlike referencing from the a .net Framework application, which can only run on 
Windows (or Linux using Mono).
 
## Setup
This package is built using .net Standard 2.1 and requires the .net Core 3.1 SDK, it can be downloaded here: 
https://www.microsoft.com/net/download/dotnet-core/3.1

IDE of Visual Studio or Visual Studio Code, can be downloaded here:
https://visualstudio.microsoft.com/downloads/

## How to access this package
All of the Cloud.Core.* packages are published to a internal NuGet feed.  To consume this on your local development machine, please add the following feed to your feed sources in Visual Studio:
https://pkgs.dev.azure.com/cloudcoreproject/CloudCore/_packaging/Cloud.Core/nuget/v3/index.json
 
For help setting up, follow this article: https://docs.microsoft.com/en-us/vsts/package/nuget/consume?view=vsts
