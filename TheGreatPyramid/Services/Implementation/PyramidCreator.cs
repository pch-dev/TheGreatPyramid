using System;
using System.Collections.Generic;
using TheGreatPyramid.Helpers;
using TheGreatPyramid.Models;
using TheGreatPyramid.Repositories;
using TheGreatPyramid.Services.Interface;

namespace TheGreatPyramid.Services.Implementation
{
    public class PyramidCreator : IPyramidCreator
    {
        private readonly IFileRepository fileRepository;
        private readonly char splitChar;

        public PyramidCreator(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));

            splitChar = ' ';
            Lines = new List<string>();
            PendingLine = new List<string>();
        }

        public IList<string> Lines { get; set; }
        public IList<string> PendingLine { get; set; }

        public Pyramid CreatePyramid()
        {
            var pyramid = new Pyramid();

            Lines = GetInput();

            foreach(var line in Lines)
            {
                PendingLine = line.Split(splitChar);

                var pyramidLevel = BuildPyramidLevel();

                pyramid.AddLevel(pyramidLevel);
            }

            return pyramid;
        }

        private string[] GetInput()
        {
            return fileRepository.Read();
        }

        private PyramidLevel BuildPyramidLevel()
        {
            var pyramidLevel = new PyramidLevel();

            for (var index = 0; index < PendingLine.Count; index++)
            {
                var item = PendingLine[index];

                var number = item.ToInteger();

                pyramidLevel.AddItem(number, index);
            }

            return pyramidLevel;
        }
    }
}
