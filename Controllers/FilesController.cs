using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Test
{
		[Route("files")]
		[ApiController]
		public class FilesController : BaseController
		{
			[HttpPost("upload")]
			public async Task<IActionResult> UploadFile([FromForm] UploadFileData data)
			{
				var s3Connection = new S3();
				bool fileUploaded = await s3Connection.UploadFileAsync(data);
				if (fileUploaded)
					return Ok();
				else
					return BadRequest();
			}
			
			[HttpGet("download")]
			public async Task<IActionResult> DownloadFile([FromQuery] DownloadFileData parameters)
			{
				var s3Connection = new S3();
				bool fileDownloaded = await s3Connection.DownloadFileAsync(parameters);
				if (fileDownloaded)
					return Ok();
				else
					return BadRequest();
			}
		}
}