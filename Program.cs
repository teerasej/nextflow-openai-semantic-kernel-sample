using Microsoft.SemanticKernel;

var kernel = Kernel.Builder.Build();


// Azure OpenAI
// kernel.Config.AddAzureTextCompletionService(
//     "text-davinci-003",                  // Azure OpenAI Deployment Name
//     "https://contoso.openai.azure.com/", // Azure OpenAI Endpoint
//     "...your Azure OpenAI Key...",       // Azure OpenAI Key
// );

// Alternative using OpenAI
kernel.Config.AddOpenAITextCompletionService(
    "text-davinci-003",               // OpenAI Model name
    ""       // OpenAI API Key
);

var prompt = @"{{$input}}

One line TLDR with the fewest words.";

var summarize = kernel.CreateSemanticFunction(prompt);

string text = @"
1st Law of Thermodynamics - Energy cannot be created or destroyed.
2nd Law of Thermodynamics - For a spontaneous process, the entropy of the universe increases.
3rd Law of Thermodynamics - A perfect crystal at zero Kelvin has zero entropy.";

Console.WriteLine(await summarize.InvokeAsync(text));