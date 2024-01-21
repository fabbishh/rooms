import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { CKEditor } from '@ckeditor/ckeditor5-react';
import React, { useEffect, useState } from 'react'

type Props = {
    value?: string;
    onChange?: any
}

const Editor = ({ value, onChange }: Props) => {
    const [data, setData] = useState<string>(value || "")

    const editorConfig = {
        dataProcessor: {
            htmlToData(viewFragment: any, modelWriter: any) {
                return viewFragment;
            },
            dataToHtml(modelFragment: any, viewWriter: any) {
                return modelFragment;
            },
        },
        toolbar: ['heading', '|', 'bold', 'italic', 'link', 'bulletedList', 'numberedList', 'blockQuote'],
        heading: {
            options: [
                { model: 'paragraph', title: 'Параграф', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Заголовок 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Заголовок 2', class: 'ck-heading_heading2' },
            ],
            placeholder: 'Выберите заголовок',
        },
    } as any;

    useEffect(() => {
        onChange(data)
    }, [data])

    const handleChange = (e: any, editor: any) => {
        const data = editor.getData();
        setData(data)
    }

    return (
        <CKEditor
            editor={ClassicEditor}
            data={value}
            onChange={handleChange}
            config={editorConfig}
        />
    )
}

export default Editor