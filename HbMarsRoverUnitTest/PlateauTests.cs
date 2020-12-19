using System;
using FluentAssertions;
using HbMarsRover;
using Xunit;

namespace HbMarsRoverUnitTest
{
    public class PlateauTests
    {
        [Theory]
        [InlineData(3,3)]
        [InlineData(4,4)]
        [InlineData(5,5)]
        [InlineData(6,6)]
        public void Should_Success_Create_Plateau_When_Given_Valid_Parameters(int width,int height)
        {
            Plateau plateau = new();
            
            plateau.SetHeight(height);
            plateau.SetWidth(width);
            
            plateau.Should().NotBeNull();
            plateau.Width.Should().Be(width);
            plateau.Height.Should().Be(height);
        }
        
        [Theory]
        [InlineData(4,-3)]
        [InlineData(5,-1)]
        public void Should_Fail_Create_Plateau_When_Given_Invalid_Height(int width,int height)
        {
            Plateau plateau = new();
            
            Assert.Throws<ArgumentException>(() => plateau.SetHeight(height));
        }
        
        [Theory]
        [InlineData(-5,3)]
        [InlineData(-1,4)]
        public void Should_Fail_Create_Plateau_When_Given_Invalid_Width(int width,int height)
        {
            Plateau plateau = new();
            
            Assert.Throws<ArgumentException>(() => plateau.SetWidth(width));
        }
    }
}