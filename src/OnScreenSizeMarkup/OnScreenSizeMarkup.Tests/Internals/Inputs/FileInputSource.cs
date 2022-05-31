using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OnScreenSizeMarkup.Forms.Tests.Internals.Inputs
{
    public class FileInputSource<T> : FileInputParamsBase<T>
    {

        //protected override string FileName => "device-sizes.json";
        // You may want to override the base file and sub folder like so. Note the .json will be added to the filename

        /*
        protected override string FileName => "MyNewFileName";  
        protected override string DataFilesSubFolder => "SomeSubFolder";
        */
    }
}
