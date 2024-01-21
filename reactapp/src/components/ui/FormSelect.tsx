import React, { FC, SelectHTMLAttributes } from "react";
import { UseFormRegister } from "react-hook-form";

interface SelectProps {
  register: UseFormRegister<any>; // Замените `any` на конкретный тип данных формы при необходимости
  options: string[];
  name: string;
}

const FormSelect: FC<SelectProps & SelectHTMLAttributes<HTMLSelectElement>> = ({
  register,
  options,
  name,
  ...rest
}) => {
  return (
    <select {...register(name)} {...rest}>
      {options.map((value) => (
        <option key={value} value={value}>
          {value}
        </option>
      ))}
    </select>
  );
};

export default FormSelect;
