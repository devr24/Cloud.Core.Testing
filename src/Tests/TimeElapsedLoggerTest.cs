using System;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    [IsUnit]
    public class TimeElapsedLoggerTest
    {
        /// <summary>Checking the start and stop of the monitor records records the elapsed time.</summary>
        [Fact]
        [LogExecutionTime] // example usage of attribute
        public void Test_TimeElapsedLoggerTest_StartStop()
        {
            // Arrange
            var logger = new TimeElapsedMonitor(false);

            // Act and Assert
            logger.IsRunning.Should().BeFalse();

            logger.Start();
            logger.IsRunning.Should().BeTrue();

            Thread.Sleep(1000);

            logger.Stop();
            logger.IsRunning.Should().BeFalse();

            logger.Elapsed.Should().BeGreaterThan(TimeSpan.MinValue);
        }

        /// <summary>Checking reset does actually reset the elapsed time.</summary>
        [Fact]
        public void Test_TimeElapsedLoggerTest_Reset()
        {
            using (var logger = new TimeElapsedMonitor())
            {
                logger.IsRunning.Should().BeTrue();

                Thread.Sleep(1000);

                logger.Stop();
                logger.IsRunning.Should().BeFalse();

                logger.Elapsed.Should().BeGreaterThan(TimeSpan.Zero);

                logger.Reset();

                logger.Elapsed.Should().Be(TimeSpan.Zero);
            }
        }
    }
}
