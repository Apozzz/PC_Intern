export interface PizzaOrderResponseDto {
    id: number;
    sizeName: string;
    toppingNames: string[];
    totalCost: number;
}