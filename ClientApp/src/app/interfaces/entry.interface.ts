export interface Nutrition {
    id: string,
    entry: Entry,
    calories: number,
    protein: number,
    carbohydrates: number,
    fats: number
}

export interface Training {
    id: string,
    entry: Entry,
    trainingType: TrainingType,
    caloriesBurned: number,
    duration: number
}

export interface Entry {
    userId: string,
    dateOfEntry: Date, 
    updated: Date
}

export enum TrainingType {
    Cardio = "Cardio",
    Strength = "Strength"
}