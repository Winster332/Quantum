using System;
using FluentAssertions;
using Quantum.DOM;
using Quantum.DOM.Events;
using Xunit;

namespace Quantum.Tests.Events
{
    public class EventTargetTest : QuantumTest
    {
        public EventTarget EventTarget;
        
        public EventTargetTest()
        {
            EventTarget = new EventTarget();
        }

        [Fact]
        public void CreateEventTest()
        {
            var @event = new Event<IBuildEvent>();
            var assertEvent = default(Event<IBuildEvent>);
            var count = 0;
            
            EventTarget.AddEventListener<IBuildEvent>(e =>
            {
                assertEvent = e;
                count++;
            });
            EventTarget.AddEventListener<IBuildEvent>(e =>
            {
                assertEvent = e;
                count++;
            });
            
            EventTarget.DispatchEvent(@event);

            assertEvent.Should().NotBeNull();
            assertEvent.Type.Should().Be<IBuildEvent>();

            count.Should().BeGreaterOrEqualTo(2);
        }

        [Fact]
        public void RemoveEventTest()
        {
            var @event = new Event<IBuildEvent>();
            EventTarget.AddEventListener<IBuildEvent>(e => {});
            EventTarget.RemoveEventListener<IBuildEvent>();
            var exception = default(Exception);

            try
            {
                EventTarget.DispatchEvent(@event);
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