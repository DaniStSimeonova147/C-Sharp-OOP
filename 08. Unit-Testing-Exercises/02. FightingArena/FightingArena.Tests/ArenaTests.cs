﻿using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void TestIfEnrollWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestEnrollingExistingWorrior()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            });
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            int expectedCount = 1;

            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void TestIfFightWorksCorrectly()
        {
            int expectedAttHp = 95;
            int expectedDefHp = 40;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttHp, attacker.HP);
            Assert.AreEqual(expectedDefHp, defender.HP);

        }

        [Test]
        public void TestFightingMissingWarrior()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacker);
            //Missing enroll on defender

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacker.Name, defender.Name);
            });
        }
    }
}
