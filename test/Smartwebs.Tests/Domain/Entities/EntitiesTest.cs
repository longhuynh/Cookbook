﻿using Xunit;

namespace Smartwebs.Tests.Domain.Entities
{
    public class EntitiesTest
    {
        [Fact]
        public void EqualityOperatorWorks()
        {
            var w1 = new Worker { Id = 5, Name = "Long Huynh" };
            var w2 = new Worker { Id = 5, Name = "Long Huynh" };

            Assert.True(w1 == w2, "Same class with same Id must be equal");
            Assert.True(w1.Equals(w2), "Same class with same Id must be equal");
            
            Worker w3 = null;
            Worker w4 = null;

            Assert.True(w3 == w4, "Null objects in same class must be equal");

            var m1 = new Manager { Id = 5, Name = "Long Huynh", Title = "Software Architect" };

            Assert.True(m1 == w1, "Derived classes must be equal if their Ids are equal");
            
            var d1 = new Department {Id = 5, Name = "IVR"};

            Assert.False(m1 == d1, "Different classes must not be considered as equal even if their Ids are equal!");

            var w5 = w1;
            w5.Id = 6;

            Assert.True(w5 == w1, "Same object instance must be equal.");
        }

        [Fact]
        public void IsTransientWorks()
        {
            var w1 = new Worker { Name = "Long Huynh" };
            var w2 = new Worker { Id = 5, Name = "Long Huynh" };

            Assert.True(w1.IsTransient());
            Assert.False(w2.IsTransient());
        }
    }
}
