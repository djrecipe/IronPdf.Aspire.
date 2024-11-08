using IronPdf.Aspire.AI.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

// parameters 
var azureEndpoint = builder.AddParameter("AzureOpenAI-Endpoint", true);
var apiKey = builder.AddParameter("AzureOpenAI-ApiKey", true);
var chatCompletionDeployment = builder.AddParameter("AzureOpenAI-ChatDeployment");
var embeddedDeployment = builder.AddParameter("AzureOpenAI-EmbeddedDeployment");
var ironPdfLicenseKey = builder.AddParameter("IronPdf-LicenseKey", true);


var pdfEngine = builder.AddIronEngine("pdfengine");

var chromadb = builder.AddChromaDb("chromadb");

builder.AddProject<Projects.IronPdf_Aspire_AI_Web>("webfrontend")
		.WithEnvironment("AzureOpenAI:Endpoint", azureEndpoint)
		.WithEnvironment("AzureOpenAI:ApiKey", apiKey)
		.WithEnvironment("AzureOpenAI:ChatCompletionDeploymentName", chatCompletionDeployment)
		.WithEnvironment("AzureOpenAI:EmbeddedDeploymentName", embeddedDeployment)
		.WithEnvironment("IronPdf:LicenseKey", ironPdfLicenseKey)
		.WithExternalHttpEndpoints()
		.WithReference(pdfEngine)
		.WaitFor(pdfEngine)
		.WithReference(chromadb);

builder.Build().Run();
