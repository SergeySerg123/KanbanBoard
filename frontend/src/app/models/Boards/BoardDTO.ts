import { GoalDTO } from "../Goals/GoalDTO";

export interface BoardDTO {
    goals: GoalDTO[],
    authorId: string
}