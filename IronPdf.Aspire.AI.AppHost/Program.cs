using IronPdf.Aspire.AI.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

// NOTE 12/21/24: must match name used when calling `.AddPdfGenerator("<name>")`
var pdfEngine = builder.AddIronEngine("pdfengine");

var chromadb = builder.AddChromaDb("chromadb");

var apiService = builder.AddProject<Projects.IronPdf_Aspire_AI_ApiService>("apiservice");

builder.AddProject<Projects.IronPdf_Aspire_AI_Web>("webfrontend")
    .WithEnvironment("AzureOpenAI:Endpoint", builder.Configuration["AzureOpenAI:Endpoint"])
    .WithEnvironment("AzureOpenAI:ApiKey", builder.Configuration["AzureOpenAI:ApiKey"])
    .WithEnvironment("IronPdf:LicenseKey", builder.Configuration["IronPdf:LicenseKey"])
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(pdfEngine)
    .WithReference(chromadb);

builder.Build().Run();
