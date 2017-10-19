// Author: GitGub on Reddit
// Link: https://www.reddit.com/r/learnprogramming/comments/77a49n/c_help_refactoring_an_ugly_method_with_lots_of_if/

    //Calculate height from boneLength, bone, gender, and age
    private float CalculateHeight(float boneLength, string boneType, string gender, int age)
    {
        float height = 0;

        if (gender == "Male")
        {
            if (boneType == "Femur")
            {
                height = 69.089f + (2.238f * boneLength) - age * 0.06f;
            }
            else if (boneType == "Tibia")
            {
                height = 81.688f + (2.392f * boneLength) - age * 0.06f;
            }
            else if (boneType == "Humerus")
            {
                height = 73.570f + (2.970f * boneLength) - age * 0.06f;
            }
            else if (boneType == "Radius")
            {
                height = 80.405f + (3.650f * boneLength) - age * 0.06f;
            }
        }
        else if (gender == "Female")
        {
            if (boneType == "Femur")
            {
                height = 61.412f + (2.317f * boneLength) - age * 0.06f;
            }
            else if (boneType == "Tibia")
            {
                height = 72.572f + (2.533f * boneLength) - age * 0.06f;
            }
            else if (boneType == "Humerus")
            {
                height = 64.977f + (3.144f * boneLength) - age * 0.06f;
            }
            else if (boneType == "Radius")
            {
                height = 73.502f + (3.876f * boneLength) - age * 0.06f;
            }
        }
        return height;
    }
