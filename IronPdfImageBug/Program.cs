using System;
using System.IO;
using System.Reflection;
using IronPdf;

namespace IronPdfImageBug
{
	class Program
	{

		public static string AssemblyDirectory
		{
			get
			{
				var codeBase = Assembly.GetExecutingAssembly().CodeBase;
				var uri = new UriBuilder(codeBase);
				var path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}

		static void Main(string[] args)
		{
			var html = $@"
						<html>
						  <head>
						    <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>
						    <link rel=""stylesheet"" href=""anwb-print.css""/>
						    </head>
						  <body class=""{AssemblyDirectory}\\page-size-a4"">
						<section class=""accommodationinformation avoid-break"">
							Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at lorem massa. Nam ornare sem viverra nisl blandit porttitor. Suspendisse neque lacus, mattis non mattis ac, consequat eu augue. Mauris porttitor elementum libero, non rhoncus urna rutrum vitae. Quisque molestie aliquet ultrices. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi quis pretium velit, a imperdiet est.
							
							Vestibulum vel dolor consequat, tristique odio eu, mollis lorem. Vestibulum ornare auctor libero, vel lobortis leo dictum non. Etiam sit amet nulla at nulla pharetra tempor. Sed pulvinar est sed nunc egestas, in molestie neque eleifend. Morbi purus nisl, molestie quis molestie et, fermentum vitae nulla. Mauris sed cursus lectus, sit amet consequat massa. Sed pharetra tempus elit nec efficitur.
							
							Donec vitae interdum libero. Curabitur vestibulum eros vel auctor condimentum. In hac habitasse platea dictumst. Vivamus non efficitur dolor, in convallis magna. Pellentesque et dolor at magna dictum dapibus. Phasellus ipsum nunc, pretium vitae volutpat vitae, tincidunt non felis. Nunc mattis commodo semper. Donec commodo pellentesque dolor, vitae egestas lectus pellentesque ac. Aenean quis erat non sem placerat pellentesque. Ut laoreet in urna ac rhoncus. Nam interdum elementum nibh. Nulla laoreet lobortis justo ac vulputate. Vivamus sollicitudin justo aliquet arcu tincidunt, non sagittis lacus cursus. Vestibulum facilisis dolor vitae urna rutrum, non dignissim eros dapibus.
							
							Pellentesque dapibus luctus massa sed tristique. Donec mattis lacinia ex vel porttitor. Proin elementum molestie dui, a porttitor augue feugiat at. Phasellus pretium, lorem vitae consectetur pellentesque, magna massa vestibulum massa, et placerat neque felis vitae diam. Quisque scelerisque suscipit neque, a molestie arcu rhoncus vitae. Nullam porttitor enim posuere lacus fringilla, et fringilla urna luctus. Fusce et fringilla elit, sed scelerisque nulla. Aliquam cursus tincidunt felis id ultricies. Cras eu nisl suscipit, mollis metus sed, ultricies leo. Etiam est est, hendrerit ac sem commodo, dictum dapibus nibh. Praesent et justo cursus, lacinia nisl ut, elementum nunc. Sed metus quam, dapibus sit amet leo in, cursus malesuada felis. Proin quis urna a erat vehicula sodales sit amet at libero. Nullam commodo metus nibh, at porttitor eros luctus sed. Cras at porttitor urna, id luctus risus. Nulla euismod bibendum ultricies.
							
							<section class=""accommodationinformation-images"">
								<div class=""img"" style=""background-image:url(https://d2csxpduxe849s.cloudfront.net/media/D9C47D27-CF22-4106-BDD62A07BB6C91E1/17DE6886-846E-4E61-9ABF61498FF519FD/61450B17-9B6C-4B78-AF6EFF3D1A8406D8/Small-Duitsland_Eifel_Lindner_N-rburgrin_Ferienpark_Vakantiepark1.jpg)"">
								</div>
							</section>
						</section>
						</body>
						</html>";

			var renderer = new HtmlToPdf();
			renderer.RenderHtmlAsPdf(html).SaveAs("html-string.pdf");

			Console.WriteLine("Done!");
		}
	}
}
