<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'

export default {
  name: 'OrderList',
  components: {
    Showcase
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список заказов',
        linkToCreate: '/orders/create',
        createCaption: 'Создать заказ',
        tableHeaders: [
          'Номер заказа',
          'Клиент',
          'Сотрудник',
          'ТК',
          'Номер адреса',
          'ТТН',
          'Платежный документ',
          'Дата заказа',
          'Дата отгрузки',
          'Дата доставки',
          'Статус',
          'Принят ТК',
          'Принят клиентом',
          'Примечание'
        ],
        tableData: [
          {
            id: '7823',
            client: 'ООО "Построй-ка',
            employee: 'Иванов И.И.',
            tc: 'Паровёз',
            address: '1732',
            ttn: '29873/НУ1',
            payment_doc: '597824',
            order_date: '27.06.2021',
            shipment_date: '29.06.2021',
            delivery_date: '01.07.2021',
            status: 'Завершен',
            accept_tc: 'Да',
            accept_client: 'Да',
            extra: ''
          }
        ],
        sortTypes: [
          'Номер заказа',
          'Клиент',
          'Сотрудник',
          'ТК',
          'Номер адреса',
          'ТТН',
          'Платежный документ',
          'Дата заказа',
          'Дата отгрузки',
          'Дата доставки',
          'Статус',
          'Принят ТК',
          'Принят клиентом',
          'Примечание'
        ]
      }
    }
  }
}
</script>
