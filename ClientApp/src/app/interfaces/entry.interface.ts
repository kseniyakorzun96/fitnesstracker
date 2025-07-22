export interface Nutrition extends DataEntry {
    calories: number,
    protein: number,
    carbohydrates: number,
    fats: number
}

export interface Weigth extends DataEntry {
    value: number,
}

export interface Training extends DataEntry{
    trainingType: TrainingType,
    caloriesBurned: number,
    duration: number
}

export interface DataEntry {
    id: string,
    userId: string,
    dateOfEntry: Date, 
    updated?: Date
}

export enum TrainingType {
    Cardio = "Cardio",
    Strength = "Strength"
}

export interface CData {
    name: string,
    value: number
}