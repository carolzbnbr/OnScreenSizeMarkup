using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OnScreenSizeMarkup.Forms.Tests.Internals.Inputs
{
    public class FileInputParamsBase<TTestCaseParams> : IEnumerable
    {
        protected virtual string DataFilesSubFolder => "TestDataFiles";

        protected virtual string FileName => "device-sizes.json";

        private string GetFilePath()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (directoryName == null)
                throw new Exception("Couldn't get assembly directory");

            var path = Path.Combine(directoryName, DataFilesSubFolder, $"{FileName}");

            return path;
        }

        public IEnumerator GetEnumerator()
        {
            var testFixtureParams = JsonConvert.DeserializeObject<TTestCaseParams[]>(File.ReadAllText(GetFilePath()));
            //var genericItems = testFixtureParams[$"{typeof(TTestCaseParams).Name}"].ToObject<IEnumerable<TTestCaseParams>>();

            foreach (var item in testFixtureParams)
            {
                yield return new object[] { item };
            }
        }
    }
}
