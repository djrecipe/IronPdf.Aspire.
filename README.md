### Benefits of using IronPdf in Aspire.NET
1. Easy container-setup - no longer have to fiddle around with Docker!
2. Easy service connections
3. Orchestrate, organize, and monitor all of your software components & services in one place

### IronPDF and OpenAI Using Aspire.NET
1. Retreive your OpenAI credentials key and endpoint from the OpenAI platform.
2. Fill-in your OpenAI credentials in the `IronPdf.Aspire.AI.AppHost/appsettings.json` file under the `AzureOpenAI` section:

```json
{
    "AzureOpenAI": {
        "Endpoint": "https://your-azure-endpoint/",
        "ApiKey": "your-api-key"
    }
}
```

3. Retrieve a valid IronPDF license key.
4. Fill-in your `ironsoftwareofficial/ironpdfengine` version and IronPdf license key in the `IronPdf.Aspire.AI.AppHost/appsettings.json` file under the `IronPdf` section:

```json
{
    "IronPdf": {
        "EngineVersion": "your-ironpdf-engine-version",
        "LicenseKey": "your-license-key"
    }
}
```

**Note:** To find the `ironsoftwareofficial/ironpdfengine` version, follow this [link](https://hub.docker.com/r/ironsoftwareofficial/ironpdfengine/tags).

5. Ensure you have the correct `chromadb/chroma` version specified in the `IronPdf.Aspire.AI.AppHost/appsettings.json` file under the `Chroma` section:

```json
{
    "Chroma": {
        "ChromaVersion": "your-chroma-version"
    }
}
```

**Note:** To find the `chromadb/chroma` version, follow this [link](https://hub.docker.com/r/chromadb/chroma/tags).

## Notes
You may use Docker for desktop to ensure your chrome DB and IronPdfEngine are up-and-running properly.

Enjoy!
