<template>
  <showcase-create v-bind="createData" />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import { required } from '@/utils/validation/i18n-validators'

export default {
  name: 'OrderCreate',
  components: {
    ShowcaseCreate
  },
  data: () => {
    return {
      createData: {
        title: 'Создать заказ',
        fields: [
          {
            label: 'Клиент',
            type: 'select',
            modelValue: 'client',
            validation: { required },
            values: [
              {
                text: 'Максим',
                value: 1
              }
            ]
          },
          {
            label: 'ТК',
            type: 'select',
            modelValue: 'tc',
            validation: { required },
            values: [
              {
                text: 'Максим',
                value: 1
              }
            ]
          },
          {
            label: 'Адрес',
            modelValue: 'address',
            validation: { required },
            placeholder: 'Адрес'
          },
          {
            label: 'Номер ТТН',
            modelValue: 'ttn',
            validation: { required },
            placeholder: 'ТТН'
          },
          {
            label: 'Стоимость заказа',
            modelValue: 'cost',
            validation: { required },
            placeholder: 'Стоимость'
          },
          {
            label: 'Стоимость заказа',
            modelValue: 'orderCost',
            validation: { required },
            placeholder: 'Стоимость'
          },
          {
            label: 'Номер платежного документа',
            modelValue: 'paymentDoc',
            validation: { required },
            placeholder: 'Номер'
          },
          {
            label: 'Дата заказа',
            modelValue: 'orderDate',
            validation: { required },
            type: 'date'
          },
          {
            label: 'Дата отгрузки',
            modelValue: 'shippingDate',
            validation: { required },
            type: 'date'
          },
          {
            label: 'Дата доставки',
            modelValue: 'deliveryDate',
            validation: { required },
            type: 'date'
          },
          {
            label: 'Статус',
            modelValue: 'status',
            type: 'select',
            validation: { required },
            values: [
              {
                text: 'В доставке',
                value: 1
              }
            ]
          },
          {
            label: 'Принято ТК',
            modelValue: 'acceptTc',
            type: 'checkbox',
            cols: ['col-auto']
          },
          {
            label: 'Принято клиентом',
            modelValue: 'acceptClient',
            type: 'checkbox',
            cols: ['col-auto']
          },
          {
            label: 'Примечание',
            placeholder: 'Примечание',
            modelValue: 'extra',
            type: 'textarea',
            cols: ['col-md-12']
          }
        ],
        enableAddedFields: true,
        subtitle: 'Товары в заказе',
        addedFields: [
          {
            label: 'Артикул',
            placeholder: 'Артикул',
            modelValue: 'art'
          },
          {
            label: 'Количество',
            placeholder: 'Кол-во',
            type: 'number',
            modelValue: 'count'
          }
        ]
      }
    }
  }
}
</script>
