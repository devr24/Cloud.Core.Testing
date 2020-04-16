using System;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    public class TimeElapsedLoggerTest
    {
        [Fact, IsUnit]
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


        [Fact, IsUnit]
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
