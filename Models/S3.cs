using Microsoft.AspNetCore.Http

namespace Test
{
	public class UploadFileData
	{
		public IFormFile File { get; set; }
		public string BucketName { get; set; }
		public string FolderName { get; set; }
	}
	
	public class DownloadFileData
	{
		public string BucketName { get; set; }
		public string FolderName { get; set; }
	}
}

using Amazon.S3.Transfer;
using System;
using System.IO;

namespace Test
{
	public class S3
	{
		private readonly ITransferUtility _transfer;
		
		public S3(ITransferUtility transfer)
		{
			_transfer = transfer;
		}
		
		public async Task<bool> UploadAsync(UploadFile data)
		{
			using var memoryStream = new MemoryStream();
			data.File.CopyTo(memoryStream);
			memoryStream.Position = 0;
			
			await _transfer.UploadAsync(memoryStream, data.BucketName, data.FolderName);
			
			return true;
		}
	}
}
		