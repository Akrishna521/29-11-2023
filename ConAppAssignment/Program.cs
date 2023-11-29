using System;

class Program
{
    delegate void SpinHandler(ref int energyLevel, ref int winningProbability);

    static void Main()
    {
        int energyLevel = 1;
        int winningProbability = 100;
        int spinCount = 0;
        SpinHandler[] spinHandlers =
        {
            (ref int e, ref int wp) => { e += 1; wp += 10; },
            (ref int e, ref int wp) => { e += 2; },
            (ref int e, ref int wp) => { e -= 3; wp -= 30; },
            (ref int e, ref int wp) => { e += 4; wp += 10; },
            (ref int e, ref int wp) => { e += 5; },
            (ref int e, ref int wp) => { e -= 1; wp -= 50; },
            (ref int e, ref int wp) => { e += 1; wp += 70; },
            (ref int e, ref int wp) => { e -= 2; wp -= 20; },
            (ref int e, ref int wp) => { wp -= 30; },
            (ref int e, ref int wp) => { e += 10; wp += 100; },
        };

        while (spinCount < spinHandlers.Length)
        {
            Console.WriteLine($"Spin {spinCount + 1}: Energy Level = {energyLevel}, Winning Probability = {winningProbability}");
            spinHandlers[spinCount].Invoke(ref energyLevel, ref winningProbability);
            spinCount++;
        }

        if (energyLevel >= 4 && winningProbability > 60)
        {
            if (energyLevel >= 1)
            {
                Console.WriteLine("Winner");
            }
            else
            {
                Console.WriteLine("Runner");
            }
        }
        else if (energyLevel > 0)
        {
            Console.WriteLine("Logger");
        }
        else
        {
            Console.WriteLine("Pago");
        }
    }
}