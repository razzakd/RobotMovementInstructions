using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToyRobot;

namespace UnitTestToyRobot
{
    [TestClass]
    public class TestInstruction
    {
        /// <summary>
        /// TEST CASE 1
        /// </summary>
        [TestMethod]
        public void UintTest1()
        {
            // setup
            ITable board = new Table(5, 5);
            ICommandProcessor cmdProcessor = new CommandProcessor();
            IRobot robot = new Robot();
            var instruction = new Instruction(robot, board, cmdProcessor);

            instruction.processInstruction("PLACE 0,0,NORTH".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 0,1,NORTH", instruction.GenerateReport());
        }

        /// <summary>
        /// TEST CASE 2
        /// </summary>
        [TestMethod]
        public void UintTest2()
        {
            // setup
            ITable board = new Table(5, 5);
            ICommandProcessor cmdProcessor = new CommandProcessor();
            IRobot robot = new Robot();
            var instruction = new Instruction(robot, board, cmdProcessor);

            instruction.processInstruction("PLACE 0,0,NORTH".Split(' '));
            instruction.processInstruction("LEFT".Split(' '));
            instruction.processInstruction("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 0,0,WEST", instruction.GenerateReport());
        } 
        /// <summary>
        /// TEST CASE 3
        /// </summary>
        [TestMethod]
        public void UintTest3()
        {
            // setup
            ITable board = new Table(5, 5);
            ICommandProcessor cmdProcessor = new CommandProcessor();
            IRobot robot = new Robot();
            var instruction = new Instruction(robot, board, cmdProcessor);

            instruction.processInstruction("PLACE 1,2,EAST".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("LEFT".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("REPORT".Split(' '));


            // assert
            Assert.AreEqual("Output: 3,3,NORTH", instruction.GenerateReport());
        } 

        /// <summary>
        /// Test Case in the reuqirement
        /// </summary>
        [TestMethod]
        public void UintTest4()
        {
            // setup
            ITable board = new Table(5, 5);
            ICommandProcessor cmdProcessor = new CommandProcessor();
            IRobot robot = new Robot();
            var instruction = new Instruction(robot, board, cmdProcessor);

            instruction.processInstruction("PLACE 1,2,EAST".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("LEFT".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("PLACE 3,1".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("REPORT".Split(' '));


            // assert
            Assert.AreEqual("Output: 3,2,NORTH", instruction.GenerateReport());
        }
        /// <summary>
        /// Invalid Place Instruction. Outside the table dimentions
        /// </summary>
        [TestMethod]
        public void TestInValidPlaceInstruction()
        {
            // setup
            ITable board = new Table(5, 5);
            ICommandProcessor cmdProcessor = new CommandProcessor();
            IRobot robot = new Robot();
            var instruction = new Instruction(robot, board, cmdProcessor);

            instruction.processInstruction("PLACE -1,-3,SOUTH".Split(' '));

            // assert
            Assert.IsNull(robot.Position);
        }
        [TestMethod]
        public void TestValidMoveInstruction()
        {
            // setup
            ITable board = new Table(5, 5);
            ICommandProcessor cmdProcessor = new CommandProcessor();
            IRobot robot = new Robot();
            var instruction = new Instruction(robot, board, cmdProcessor);

            // act
            instruction.processInstruction("PLACE 3,2,SOUTH".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 3,1,SOUTH", instruction.GenerateReport());
        }

        /// <summary>
        /// Test case:
        /// 
        /// </summary>
        [TestMethod]
        public void TestInvalidMoveInstruction()
        {
            // setup
            ITable board = new Table(5, 5);
            ICommandProcessor cmdProcessor = new CommandProcessor();
            IRobot robot = new Robot();
            var instruction = new Instruction(robot, board, cmdProcessor);

            // act
            instruction.processInstruction("PLACE 2,2,NORTH".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));

            // Push the robot out of the table. this command to be ignored
            instruction.processInstruction("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 2,4,NORTH", instruction.GenerateReport());
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestValidInstructionReport()
        {
            // setup
            ITable board = new Table(5, 5);
            ICommandProcessor cmdProcessor = new CommandProcessor();
            IRobot robot = new Robot();
            var instruction = new Instruction(robot, board, cmdProcessor);

            // act
            instruction.processInstruction("PLACE 3,3,WEST".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            instruction.processInstruction("LEFT".Split(' '));
            instruction.processInstruction("MOVE".Split(' '));
            var output = instruction.processInstruction("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 1,2,SOUTH", output);
        }
    }
}
