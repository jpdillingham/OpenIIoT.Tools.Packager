﻿using OpenIIoT.SDK.Package.Manifest;
using System;
using Utility.CommandLine;
using System.IO;
using System.Collections.Generic;
using Utility.BigFont;

namespace OpenIIoT.Packager
{
    internal class Program
    {
        #region Private Properties

        [Argument('h', "hash")]
        private static bool Hash { get; set; }

        [Argument('?', "help")]
        private static string Help { get; set; }

        [Argument('i', "include-resources")]
        private static bool IncludeResources { get; set; }

        [Argument('d', "directory")]
        private static string InputDirectory { get; set; }

        [Argument('m', "manifest")]
        private static string Manifest { get; set; }

        [Argument('o', "output")]
        private static string OutputFile { get; set; }

        [Argument('p', "package")]
        private static string Package { get; set; }

        [Operands]
        private static List<string> Operands { get; set; }

        #endregion Private Properties

        #region Private Methods

        public static void Main(string[] args)
        {
            Arguments.Populate();

            string command = "help";

            if (Operands.Count > 1)
            {
                command = Operands[1].ToLower();
            }

            if (Help != default(string))
            {
                HelpPrinter.PrintHelp(Help);
                return;
            }

            if (command == "manifest")
            {
                PackageManifest manifest = ManifestGenerator.GenerateManifest(InputDirectory, IncludeResources, Hash);

                if (OutputFile != default(string))
                {
                    try
                    {
                        File.WriteAllText(OutputFile, manifest.ToJson());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unable to write to output file '{OutputFile}': {ex.Message}");
                    }
                }
                else
                {
                    Console.Write(manifest.ToJson());
                }
            }
            else if (command == "package")
            {
            }
            else if (command == "sign")
            {
            }
            else if (command == "verify")
            {
            }
            else if (command == "create-trust")
            {
            }
            else if (command == "verify-trust")
            {
            }
            else if (command == "help")
            {
                HelpPrinter.PrintHelp(Operands.Count > 2 ? Operands[2] : default(string));
            }
        }
    }

    #endregion Private Methods
}