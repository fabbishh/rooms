import { format, parseISO } from 'date-fns';
import { ru } from 'date-fns/locale';

export const formatDateToRuLocale = (date: string | undefined) => {
    if (!date) {
        return null;
    }
    const parsedDate = parseISO(date!);
    const formattedDate = format(parsedDate, 'd MMMM yyyy', { locale: ru });

    return formattedDate;
}

export const formatDateTimeToRuLocale = (date: string | undefined) => {
  if (!date) {
      return null;
  }
  const parsedDate = parseISO(date!);
  const formattedDate = format(parsedDate, 'd MMMM yyyy HH:mm:ss', { locale: ru });

  return formattedDate;
}

export const getDatesBetween = (startDate: Date, endDate: Date) => {
    const dates = [];
    let currentDate = new Date(startDate);
    while (currentDate <= endDate) {
      dates.push(new Date(currentDate));
      currentDate.setDate(currentDate.getDate() + 1);
    }
  
    return dates;
  };
