using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SageBookApplication.Models
{
    /*public class ImageMediaFormatter : MediaTypeFormatter
    {
        public ImageMediaFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpg"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/png"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(ImageMedia);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public async override Task OnReadFromStreamAsync(
            Type type, Stream stream, HttpContentHeaders contentHeaders,
            FormatterContext formatterContext)
        {
            HttpRequestMessage request = formatterContext.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var parts = await request.Content.ReadAsMultipartAsync();
            var content = parts.First(x =>
                SupportedMediaTypes.Contains(x.Headers.ContentType));

            string fileName = content.Headers.ContentDisposition.FileName;
            string mediaType = content.Headers.ContentType.MediaType;

            using (var imgstream = await content.ReadAsStreamAsync())
            {
                byte[] imagebuffer = imgstream.ReadFully();
                return new ImageMedia(fileName, mediaType, imagebuffer);
            }
        }
    }*/
}