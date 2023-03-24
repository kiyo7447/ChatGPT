


# 
## Package
https://www.nuget.org/packages/RazorLight
## Source
https://github.com/toddams/RazorLight



## 
``` Csharp
var engine = new RazorLightEngineBuilder()
	// required to have a default RazorLightProject type,
	// but not required to create a template from string.
	.UseEmbeddedResourcesProject(typeof(ViewModel))
	.SetOperatingAssembly(typeof(ViewModel).Assembly)
	.UseMemoryCachingProvider()
	.Build();

string template = "Hello, @Model.Name. Welcome to RazorLight repository";
ViewModel model = new ViewModel {Name = "John Doe"};

string result = await engine.CompileRenderStringAsync("templateKey", template, model);
```

## í˙ÇﬂÇΩâ€ëË
* â¸çsèàóù  


## é¿çsåãâ 

========================================
Store: SuperStore
Address: 123 Main St
Employee: John Doe
Sale Date: 2023/03/23 16:32:06
----------------------------------------
Items:
Item1 x 1 - $10.0
Item2 x 2 - $10.0
Item3 x 1 - $15.0

----------------------------------------
Subtotal: $35.0
Tax (0.10 * 100)%: $3.500
Total: $38.500
----------------------------------------
Payment: Credit Card
Amount: $33.0
========================================




# éÌóﬁÇÃàÍóó
https://zenn.dev/nuits_jp/articles/2022-05-26-text-template-benckmarks


