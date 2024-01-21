import { toast } from "react-toastify";

type Message = {
  title: string;
  message: string;
}
const Msg = ( {title, message} : Message)  => (
  <div>
    <h2 className="font-bold">{title}</h2>
    <p>{message}</p>
  </div>
)

export const showNotification = (type: string, msg: string) => {
  switch (type) {
    case 'success':
      toast.success(msg)
      break;
    case 'error':
      toast.error(<Msg title="Ошибка" message={msg}/>)
      break;
    case 'warn':
      toast.warn(msg)
      break;
    case 'info':
      toast.info(msg)
      break;
    default:
      toast(msg);
  }
}