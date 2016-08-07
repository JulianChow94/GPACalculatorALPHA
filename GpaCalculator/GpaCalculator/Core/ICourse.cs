using System;

namespace GpaCalculator.Core
{
    public interface ICourse
    {
        double getWeight();

        float getValue();

        float calculateGPA();

    }
}
