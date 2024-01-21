import { SanatoriumSeasons } from "../../shared/app.enums"
import { ConvertSanatoriumSeasonsToRuLocale } from "../../utils/enumUtils";

export const getSanatoriumSeasonOptions = () => {
    let map: {value: any; label: string}[] = [];

    for(var i in SanatoriumSeasons) {
        if(typeof SanatoriumSeasons[i] === 'number') {
            map.push({value: SanatoriumSeasons[i], label: ConvertSanatoriumSeasonsToRuLocale(SanatoriumSeasons[i])});
        }
    }

    return map;
}