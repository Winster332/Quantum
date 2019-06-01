using System;
using FluentAssertions;
using Quantum.DOM;
using Quantum.DOM.Events;
using Xunit;

namespace Quantum.Tests.Events
{
    public class EventTargetTest
    {
        public Document Document;
        
        public EventTargetTest()
        {
            Document = new Document();
        }

        [Fact]
        public void CreateEventTest()
        {
            var @event = new Event<IBuildEvent>();
            var assertEvent = default(Event<IBuildEvent>);
            var count = 0;
            
            Document.AddEventListener<IBuildEvent>(e =>
            {
                assertEvent = e;
                count++;
            });
            Document.AddEventListener<IBuildEvent>(e =>
            {
                assertEvent = e;
                count++;
            });
            
            Document.DispatchEvent(@event);

            assertEvent.Should().NotBeNull();
            assertEvent.Type.Should().Be<IBuildEvent>();

            count.Should().BeGreaterOrEqualTo(2);
        }

        [Fact]
        public void RemoveEventTest()
        {
            var @event = new Event<IBuildEvent>();
            Document.AddEventListener<IBuildEvent>(e => {});
            Document.RemoveEventListener<IBuildEvent>();
            var exception = default(Exception);

            try
            {
                Document.DispatchEvent(@event);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            exception.Should().NotBeNull();
        }
    }

    public interface IBuildEvent
    {
    }
}