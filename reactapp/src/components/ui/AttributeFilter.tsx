import React, { useEffect, useState } from 'react'
import { Attribute } from '../../shared/app.interfaces';

type Props = {
    options: Attribute[];
    onOptionsChange: (selectedValues: Attribute[]) => void;
    title: string;
}

const AttributeFilter = ({ options, onOptionsChange, title }: Props) => {

    const handleOptionsChange = (option: Attribute) => {
            const changedOptions = options.map((attribute) =>
            attribute.id === option.id
                ? { ...attribute, isActive: !attribute.isActive }
                : attribute
            )
        onOptionsChange(changedOptions);
    }

    return (
        <div className="border p-4 rounded-md shadow-md mb-4">
            <h2 className="text-lg font-semibold mb-2">{title}</h2>
            {options.map(option => (
                <label key={option.id} className="flex items-center mb-2">
                    <input
                        type="checkbox"
                        checked={option.isActive}
                        onChange={() => handleOptionsChange(option)}
                        className="mr-2"
                    />
                    {option.name}
                </label>
            ))}
        </div>
    )
}

export default AttributeFilter