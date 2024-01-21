export interface SanatoriumCardProps {
    id: string;
    photoUrl: string;
    name: string;
    priceFrom: number;
    address: string;
    season: number;
    isFavourite: boolean;
    onLikeClick?: () => void;
  }

export default SanatoriumCardProps