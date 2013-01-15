﻿using System;
using System.Collections.Generic;
using System.Text;
using EventStore.ClientAPI;
using EventStore.Core.Services.Transport.Http.Codecs;

namespace EventStore.TestClient.Commands.RunTestScenarios
{
    internal class JsonEventContainer : IEvent
    {
        public Guid EventId { get; private set; }
        public string Type { get; private set; }
        public bool IsJson { get; private set; }
        public byte[] Data { get; private set; }
        public byte[] Metadata { get; private set; }

        public JsonEventContainer(object @event)
        {
            if (@event == null)
                throw new ArgumentNullException("event");

            EventId = Guid.NewGuid();
            Type = @event.GetType().Name;
            IsJson = true;

            Data = Encoding.UTF8.GetBytes(Codec.Json.To(@event));
            Metadata = Encoding.UTF8.GetBytes(Codec.Json.To(new Dictionary<string, object> { { "IsEmpty", true } }));
        }
    }
}