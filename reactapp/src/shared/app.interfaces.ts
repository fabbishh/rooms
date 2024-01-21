export interface Tour {
	id: string;
	name: string;
	type: number;
	organizer: TourOrganizer;
	touristCountFrom: number;
	touristCountTo: number;
	description: string;
	closestDate: string;
	priceByGroup?: number;
	priceByTourist?: number;
	days: number;
	imageUrl?: string;
}

export interface TourOrganizer {
	id: string;
	name: string;
}

export interface Attribute {
	id: string;
	name: string;
	isActive: boolean;
}

export interface SanatoriumFilter {
	serviceAttributeIds?: string[];
	comfortAttributeIds?: string[];
	foodAttributeIds?: string[];
	bathAttributeIds?: string[];
	regionId?: string;
	housingTypes?: number[],
	seasons?: number[],
	bedroomCounts?: number[],
	priceFrom?: number,
	priceTo?: number
}