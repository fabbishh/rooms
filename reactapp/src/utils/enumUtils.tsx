import { Status, SanatoriumSeasons } from "../shared/app.enums";

export const ConvertReservationStatusToRuLocale = (status: number) => {
    switch (status) {
        case Status.Confirmed:
          return 'Подтверждено';
        case Status.Pending:
            return 'В ожидании';
        case Status.Declined:
            return 'Отклонено';
        default:
            return 'Неизвестно';
      }
}

export const ConvertSanatoriumSeasonsToRuLocale = (status: number | string) => {
    switch (status) {
        case SanatoriumSeasons.AutumnWinter:
          return 'Осень-зима';
        case SanatoriumSeasons.SpringSummer:
            return 'Весна-лето';
        case SanatoriumSeasons.YearRound:
            return 'Круглогодично';
        default:
            return 'Неизвестно';
      }
}

export const mapSanatoriumSeason = (season: number) => {
    if(season === 0) {
        return "весна-лето"
    }
    if(season === 1) {
        return "осень-зима"
    }
    if(season === 2) {
        return "круглогодично"
    }
}

